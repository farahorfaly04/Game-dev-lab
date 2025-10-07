# Scene week2polished is the latest version with the coins implemented.

We have implemented everything required in the checklist:
 Coins shooting from the question mark block:
 - We unpacked one of the question mark blocks and added all the requirements for it:
        The question box bounces only when hit from below (not when Mario is jumping on top of it)
        Animate "blinking" of the question box
        It will spawn a coin, animated as shown
        Plays a sound effect when the coin spawns and the coin should land back inside the box
        The box sprite is changed to indicate that it's disabled once coin is spawned
        The question box, once disabled, should not bounce anymore

        Important: we tested and applied all the changes to the question mark block we unpacked during the lab, we left the others plain for now, though the process would've been more or less the same.

Coins shooting from the bricks:
- We added a 50/50% chance of coins spawning from bricks when Mario hits them with his head from below:
        It bounces once when hit from below, but not from anywhere else
        You should make two variant: can spawn a coin, or not
        It should not "break" (yet, because Mario is not in Super Mario form)
        Sound effect to be played when coin is collected
        You do not need to increase any score yet

Furthermore, we added everything in the lab:
- the bricks
- the question mark blocks
- the pipes
- the bouncy cloud
- the platform

Videos of us playing and building different stages: https://loom.com/share/folder/d9ffbea181984cdcae43e8cbd2bbf426  
Backup link: https://www.loom.com/share/4213f2c8413f48429fab704f13dede17?sid=e7e0319b-bcc2-4f37-af01-0f931feb0196
