import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Account } from '../models/Account';
import { Champion } from '../models/Champion';
import { FetchDataService } from './fetch-data.service';
import { ActivatedRoute } from '@angular/router';
import { animate, state, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['fetch-data.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})

export class FetchDataComponent {

  accountWithChampions: Account = {
    login: '',
    name: '',
    creationDate: null
  }

  constructor(private fs: FetchDataService<Account>, private route: ActivatedRoute) {

  }

  ngOnInit() {
    this.init();
  }

  async init() {
    await this.fs.getAll().then((result) => {
      this.accountWithChampions = result;
      //console.log(result);
    });
  }

  
}
