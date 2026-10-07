using System.Runtime.InteropServices;

namespace AutoKeyLight
{
    // Newer Windows 11 builds (26200+) stopped writing LastUsedTimeStop to the CapabilityAccessManager registry keys,
    // so we ask Media Foundation directly which processes are streaming from a camera.
    // https://learn.microsoft.com/en-us/windows/win32/api/mfidl/nn-mfidl-imfsensoractivitymonitor
    internal sealed class CameraActivityMonitor : IDisposable
    {
        [ComImport, Guid("d0cef145-b3f4-4340-a2e5-7a5080ca05cb"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IMFSensorActivityMonitor
        {
            void Start();
            void Stop();
        }

        [ComImport, Guid("de5072ee-dbe3-46dc-8a87-b6f631194751"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IMFSensorActivitiesReportCallback
        {
            [PreserveSig]
            int OnActivitiesReport(IMFSensorActivitiesReport report);
        }

        [ComImport, Guid("683f7a5e-4a19-43cd-b1a9-dbf4ab3f7777"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IMFSensorActivitiesReport
        {
            uint GetCount();
            IMFSensorActivityReport GetActivityReport(uint index);
        }

        [ComImport, Guid("3e8c4be1-a8c2-4528-90de-2851bde5fead"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IMFSensorActivityReport
        {
            void GetFriendlyName(IntPtr friendlyName, uint cchFriendlyName, out uint cchWritten);
            void GetSymbolicLink(IntPtr symbolicLink, uint cchSymbolicLink, out uint cchWritten);
            uint GetProcessCount();
            IMFSensorProcessActivity GetProcessActivity(uint index);
        }

        [ComImport, Guid("39dc7f4a-b141-4719-813c-a7f46162a2b8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IMFSensorProcessActivity
        {
            uint GetProcessId();
            [return: MarshalAs(UnmanagedType.Bool)]
            bool GetStreamingState();
        }

        [ComVisible(true)]
        private sealed class ReportCallback : IMFSensorActivitiesReportCallback
        {
            private readonly CameraActivityMonitor owner;

            public ReportCallback(CameraActivityMonitor owner)
            {
                this.owner = owner;
            }

            public int OnActivitiesReport(IMFSensorActivitiesReport report)
            {
                try
                {
                    bool streaming = false;
                    uint deviceCount = report.GetCount();

                    for (uint i = 0; i < deviceCount && !streaming; i++)
                    {
                        IMFSensorActivityReport device = report.GetActivityReport(i);
                        uint processCount = device.GetProcessCount();

                        // Apps often open the camera just to enumerate it, only count the ones actually streaming
                        for (uint p = 0; p < processCount && !streaming; p++)
                        {
                            streaming = device.GetProcessActivity(p).GetStreamingState();
                        }
                    }

                    owner.isCameraStreaming = streaming;
                }
                catch { }

                return 0;
            }
        }

        [DllImport("mfplat.dll")]
        private static extern int MFStartup(uint version, uint flags);

        [DllImport("mfplat.dll")]
        private static extern int MFShutdown();

        [DllImport("mfsensorgroup.dll")]
        private static extern int MFCreateSensorActivityMonitor(IMFSensorActivitiesReportCallback callback, out IMFSensorActivityMonitor activityMonitor);

        const uint MF_VERSION = 0x00020070;

        private readonly ReportCallback callback;
        private readonly IMFSensorActivityMonitor monitor;
        private volatile bool isCameraStreaming = false;

        public bool IsCameraStreaming => isCameraStreaming;

        private CameraActivityMonitor()
        {
            callback = new ReportCallback(this);

            Marshal.ThrowExceptionForHR(MFStartup(MF_VERSION, 0));
            Marshal.ThrowExceptionForHR(MFCreateSensorActivityMonitor(callback, out monitor));
            monitor.Start();
        }

        // Returns null when the API isn't available (older Windows versions)
        public static CameraActivityMonitor? TryCreate()
        {
            try
            {
                return new CameraActivityMonitor();
            }
            catch
            {
                return null;
            }
        }

        public void Dispose()
        {
            try
            {
                monitor.Stop();
                Marshal.ReleaseComObject(monitor);
                MFShutdown();
            }
            catch { }
        }
    }
}
