# GoldBadgeChallenges
Each challenge performs a different funciton.

Challenge 1:
  This program runs a menu for a cafe.
  In order to navigate the menu you simply type the appropiate number for the menu item and press enter. 
  For example, 
  To create a new menu item you would type "1" and press enter. 
  
  It also displays a list of all the menu items for reference.
  To aid in quickly finding the appropiate menu items you can search for menu items by their ID.
  In this case, the Iced Latte has an ID of 1. 
  
  You can also delete menu items based off their ID.
  You will be notified whether the content could be deleted or if it could not be found.
  
Challenge 2:
  This program runs a menu for creating and dealing with insurance claims.
  Navigation is similar to challenge 1. You just need to enter the appropiate number for the action, and press enter.
  1. You can see all the claims in the queue.
  2. Take care of claims.
  3. Enter a new claim.
  
  1. Simply shows all the claims in the queue currently
  
  2. Allows you to take care of the claim that is on top of the queue. If you deal with the claim it will be removed from the queue,
  and be removed from the program entirely. There isn't a way in this program to recover lost or "dealt with" claims.
  
  3. Allows you to create a new claim, and adds it to the queue. 
 
Challenge 3:
  The goal of this program is to allow a security administrator to manage RFID badges for doors in a facility.
  The navigation is the same as the two previous challanges, you will enter the appropiate number and press enter to navigate.
  1. Add a badge
  2. Edit a badge
  3. List all badges
  
  1. Allows for the creation of a badge and adds it to a list
  
  2. You can edit a badge by typing in the badge number you want to update. 
  It will tell you what doors the badge has access to, and asks if you want to add or remove a door.
  
  3. Simply shows a list of the badges
  
  **Known Issues**
  This program is a work in progress, and there are functional problems that need to be resolved.
  The list of badges does not display as intented. It currently shows the dictionary, and only shows the door associations in order without the badgeIDs.
  Removing/adding indvidual doors to and from badges is not currenlty possible. The DoorNames needs to be converted into a list for this to work.
  
  
