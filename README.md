# HungryHippos
A quick PoC of Hungry Hippos to get up to speed with unity 


##Intitial thoughts on the game (No project planning) 
#### Game loop

- Join
- 3-2-1-GO
- Balls drop slowly
- Can be hit back by pop out
- Can be eaten
- Can be knocked out of world and respawned in
- Highest score wins

#### Suggested points system and game play
- Easy 30 balls drop
- Medium 50 balls drop
- Hard 100 balls drop

- Red balls - bad -100 points (10%)
- Green balls +10 points (35%)
- Blue balls + 20 points (30%)
- Yellow balls + 30 points (20%)
- Purple balls + 100 points (5%)

#### Controls
- Space bar - push forward and eat
- W or forward is repel
- S or backward is attract 

Possible power ups

- Faster panels
- Harder repel/attract

Other hippos heuristic AI basic set of rules to follow

Platform will have to be slightly curved

Balls need to have rigid bodies and collision

Ui for points coming up with particles 

 Menu with play + instructions

Escape - pause menu

Jump to instructions and or exit

Local high score

#### Rough example of UI and level
--------------------------------------------------------
  Score						powerup? 
  
			\/.                                      Balls entry point 


( °)-@					@-(° )                   Apponents

			 {. .}					Your hippo 3D
			{ ° ° }
	___.							Constant panel moving left to right 
-------------------------------------------------------
           



#### Time estimates

**Original estimates:** Will keep track as I go

- Get level setup - 1 hour (make some simple mock up of models etc)
- Get game loop (Menu - Play/instructions - switch to play menu - esc to pause (exit & resume)) - 1.5 hour (Depending on UI)
- Make ball prefabs - 1 hour
- Get balls spawning - 0.5 hour
- Create player character 0.5 hour
- Create player controller 1 hour
- Create character gameplay - 2 hours (to include all collision and interaction with balls)
- Create opponent characters - 2 hours
- Link up UI - 1 hour
- Create local high scores - 1 hour
- Various small details (+POINTS UI/ Maybe some particles / maybe some character animation ) ~ 2hours if time permits.
- Plus ~ 2.5 hours for anything that may go wrong (I'm sure there'll be lots)


**Total estimated time:** ***16 hours***

