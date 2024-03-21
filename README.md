# AutoKeyLight
Automatically turns on and off your Elgato lights when you turn on and off your webcam.

![image](https://user-images.githubusercontent.com/15985195/201465765-105bb629-f124-449f-b946-a6f8cd6eb5ed.png)

The app will try finding your lights IPs from an existing Elgato Control Center installation. If that fails, please add them manually.

If you have a "phantom" IP where after removing the IP, it comes back after restarting the app, it's most likely due to the Elgato control center app being installed with the IP in its settings. To fix that, open %APPDATA%\Elgato\ControlCenter\Settings.xml and remove any \<Acessory\> tags inside \<Accessories\>, or just delete the file altogether.

To find your keylight IP:

![image](https://user-images.githubusercontent.com/15985195/174424927-f0acc48a-5e97-4d59-9b7b-bdebf4a085aa.png)

If you know your way around your router, you could get the lights fixed IPs to guarantee reliability. I've also managed to expose the lights to the internet which makes a nice little party trick.
