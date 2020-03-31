# Acceleration of Suguri 2 Data Ripper

It rips MANY file

## Instructions

### HOW USE?

First thing to note is that this ripper is only intended for use on the game's texture files. It can be used for other .pak files as well, but may have unintended side effects, such as the program attempting to decrypt a file that wasn't encrypted to begin with, resulting in it returning garbage data.

I might update it in the future to handle other types of data files, but until then use with caution. Always remember to backup any files you wish to modify as well!

### ALRIGHT, HOW DO I MEME?

For the purposes of this tutorial, let's assume you're trying to modify the game's main menu to display "YOUR_IMAGE.png", whatever that might actually be.

### K, WHERE ARE PICTURES?

Start off by locating the texture files for the game. The quickest way to do this is to right-click the game's name in the Steam library sidebar, then click on "Properties." From here, go to the "LOCAL FILES" tab and select "BROWSE LOCAL FILES..." This should take you to the game's directory. In there, open the folder labeled "mdl" and you should see a file called "texture.pak."

This is where the ripper comes in. Open up "AOS2Ripper.exe" and look at the left-hand column called "Convert AOS2 Texture Data to PNG." There are two rows labeled "Input File" and "Output Directory." Under input, select the texture.pak file, and under output choose the directory you wish to have the texture files be dumped to (by default it's whatever directory the texture.pak is in). Click "Parse Data" and wait for it to finish the extraction. Once it's done you should see a folder called "texture" in the directory you specified, with every asset inside it being a png image.

### HOW DO I GET MEME IN GAME?

As mentioned above, let's assume you want to replace the menu title with "YOUR_IMAGE.png." Inside the texture folder, navigate to the "menuMdl" folder. In there should be "ttl_logo.png", proudly displaying the game's logo. Overwrite that file with "YOUR_IMAGE.png" by renaming it to "ttl_logo.png" and then you're set to re-encrypt the files.

Go back into "AOS2Ripper.exe" and look at the right-hand column of the program titled "Convert Directory to AOS2 Texture Data." From here, select the texture folder to be the directory, then once you hit "Package Data" you'll be prompted to choose a location to save the .pak to. Name it "texture" and save it in the same directory as the original "texture.pak" (remember to back up the original file first! I just rename it to "texture_OLD.pak"). Once you select the save location the program will begin encrypting the files. After the encryption is complete, load up AOS2 and proudly see "YOUR_IMAGE.png" on the menu screen.
https://cdn.discordapp.com/attachments/344026969555599361/422255057254219778/unknown.png

## Other notes

If you replace an image file with a smaller image (say, swap a 2048x2048 image with a 512x512 one), then that image will proceed to tile until it fits the required dimensions. Not really sure why the game does that but whatever.

## The program isn't working

If an update to the game was recently pushed, then it might be possible that they changed the encryption key the game uses. At that point I'd need to update the software so that it works as intended.

If you're getting some funky errors however, feel free to open a new ticket on this repo.

## License
This project is licensed under the zlib license. Please refer to the [LICENSE.md](LICENSE.md) file for more details.

## Additional Credits
juanjp600 - For figuring out the encryption key for AOS2's data to begin with, effectively making this ripper possible. Also helped with optimizing the program's extraction speed.

RoadHog 360 - For figuring out the original encryption method used for "100% Orange Juice", which made finding the key for AOS2 possible.

Cridone - Made the lovely icon for this program. Don't ask.
