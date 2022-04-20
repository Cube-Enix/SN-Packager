# SN-Packager
This little application takes the .html and .png you choose and turns it into a .snt (SNext Game File).
THIS DOES __NOT__ convert your .sb3 or scratch files to a .html!! It only makes your .html files into valid SNext Game Files!
### For Scratch Game Developers
**To build your game**
1. Download the latest release of the Packager
2. Extract all files from the .zip and run the 'SNext Packager Tool.exe' file.
3. Follow the in-app instructions.
4. Upon building your .snt file, you can see where it is by going to where the SNext Packager's .exe is installed and there is a folder called 'Games' inside the "SNext Packager Tools_Data" folder. This holds your games and .SNTs. Click the 'SNTs (Compressed SNext Files).
5. Your built SNTs are in there. Enjoy!
### For Unity Developers (or people who wanna get their hands on this source code and actually _do_ something with it)
1. Download the source code from this page
2. Open this Unity Project in Unity **2020.1.14f1**. 
3. Do whatever with it, just make sure you add a .txt that's readable and easily findable in your build of the packager, saying "Original Utility made by Kaylerr, originally for the SNext Project". Thanks!

Notes for developers:
Already installed libraries: TextMeshPro, SharpZipLib (0.86), StandaloneFileBrowser


TroubleShooting:
#### Q: The Packager doesn't detect my image file as valid.
A: This means that your image file is not a .png.

#### Q: The Packager doesn't detect my game file as valid.
A: This means that your image file is not a .html.

#### Q: I can't find the .snt anywhere?
A: Try to reload the folder. If it doesn't show, delete the existing folder with the game's files in it, in the 'Game Folders (Not Compressed Yet)' folder, and restart the packager and create your .snt again.

##### Q: I can't exit the Packager!
A: Alt + F4 should work.

#### Q: The packager gives me a .zip instead of a .snt.
A: This means 1 of 2 things. Your computer is slow and not replacing the .zip fast enough, just restart your computer, or it's that Kaylerr left the "IsUnityTest" bool on true, and that generates a .zip file. If it's constantly pushing .zips and not .snt files, raise an issue in the SNext Discord Server, or on this Github Repository.

#### Q: I have another issue!
A: Submit a ticket on the SNext Discord Server and on this Github Repository's Issues Tab.
