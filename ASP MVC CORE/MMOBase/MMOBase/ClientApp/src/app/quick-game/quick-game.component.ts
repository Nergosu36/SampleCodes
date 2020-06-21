import { Component, OnInit } from '@angular/core';
import { trigger, state, style, animate, transition } from '@angular/animations';
import { Resources } from '../models/Game';

@Component({
  selector: 'app-quick-game',
  templateUrl: './quick-game.component.html',
  styleUrls: ['./quick-game.component.css'],
  animations: [
    trigger('smoothCollapse', [
      state('initial', style({
        height: '0',
        overflow: 'hidden',
        opacity: '0'
      })),
      state('final', style({
        overflow: 'hidden',
        opacity: '1'
      })),
      transition('initial=>final', animate('750ms')),
      transition('final=>initial', animate('750ms'))
    ]),
  ]
})
export class QuickGameComponent implements OnInit
{

  resources: Resources =
  {
    Air: 100,
    Torpedos: 5,
    Mines: 5,
    Progress: 0
  }
  gameStart = false;
  gameLoop;
  eventLoop;
  checkReactionTimer;
  dived = false;
  enemyAhead = false;
  enemyBehind = false;
  torpedoFired = false;
  minePlaced = false;
  defendedAhead = false;
  defendedBehind = false;

  torpedoTrack=0;
  
  constructor() { }

  ngOnInit()
  {
    this.init();
  }

  init()
  {

  }

  eventMaker()
  {
    let random = (Math.floor(Math.random() * 5) + 1);
    //console.log(random);
    switch(random)
    {
      case 1:
        {
          clearInterval(this.eventLoop);
          this.spawnPatrol();
          break;
        }
      case 2:
        {
          clearInterval(this.eventLoop);
          this.spawnBehind();
          break;
        }
    }
  }

  spawnPatrol()
  {
    //console.log("enemy ahead");
    this.enemyAhead = true;
    this.checkReactionTimer = setTimeout(() => { this.checkReaction(false); }, 5000);
  }

  spawnBehind()
  {
    //console.log("enemy behind");
    this.enemyBehind = true;
    this.checkReactionTimer = setTimeout(() => { this.checkReaction(true); }, 5000);
  }

  checkReaction(isBehind: boolean)
  {
    if (isBehind)
    {
      if (this.minePlaced || this.dived)
      {
        //console.log("obroniono behind");
        this.minePlaced = false;
        this.enemyBehind = false;
        this.defendedBehind = true;
        setTimeout(() => { this.defendedBehindDiv(); }, 3000);
        this.eventLoop = setInterval(() => { this.eventMaker(); }, 5000);
      }
      else
        this.gameLose(); 
    }
    if (!isBehind)
    {
      if (this.torpedoFired || this.dived)
      {
        //console.log("obroniono ahead");
        this.torpedoFired = false;
        this.enemyAhead = false;
        this.defendedAhead = true;
        this.torpedoTrack = 0;
        setTimeout(() => { this.defendedAheadDiv(); }, 3000);
        this.eventLoop = setInterval(() => { this.eventMaker(); }, 5000);
      }
      else
        this.gameLose();
    }
  }

  defendedAheadDiv()
  {
    this.defendedAhead = false;
  }

  defendedBehindDiv()
  {
    this.defendedBehind = false;
  }

  startGame()
  {
    this.gameStart = true;
    this.gameLoop = setInterval(() => { this.gameUpdate(); }, 1000);
    this.eventLoop= setInterval(() => { this.eventMaker(); }, 5000);
    this.resources.Progress = 0;
  }

  killIntervals()
  {
    clearInterval(this.gameLoop);
    clearInterval(this.eventLoop);
  }

  gameUpdate()
  {
    if (!this.dived)
      this.resources.Progress += 0.5;
    else
      this.resources.Progress += 1.0;

    if (this.torpedoFired)
    {
      if (this.torpedoTrack + 150 < 820)
        this.torpedoTrack += 150;
      else
      {
        this.torpedoFired = false;
        this.torpedoTrack = 0;
      }
    }
    
    if (this.resources.Progress >= 82)
    {
      this.gameWin();
      this.killIntervals();
    }
    if (this.resources.Air <= 0)
      this.gameLose();
    if (this.dived)
      this.resources.Air -= 20;
    else if (this.resources.Air < 100)
    {
      if ((this.resources.Air + 20) > 100)
        this.resources.Air = 100;
      else
        this.resources.Air += 20;
    }    
  }

  gameEnd()
  {
    this.gameStart = false;
    this.enemyAhead = false;
    this.enemyBehind = false;
    this.torpedoFired = false;
    this.minePlaced = false;
    this.resources.Air = 100;
    this.killIntervals();
  }

  gameStop()
  {
    this.gameEnd();
  }

  gameWin()
  {
    this.gameEnd();
  }

  gameLose()
  {
    this.gameEnd();
  }

  fireTorpedo()
  {
    this.resources.Torpedos--;
    this.torpedoFired = true;
  }

  placeMine()
  {
    this.resources.Mines--;
    this.minePlaced = true;
  }
}
