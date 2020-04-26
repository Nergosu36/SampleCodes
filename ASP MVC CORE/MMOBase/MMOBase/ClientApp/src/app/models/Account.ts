import { Champion } from './Champion';
import { DatePipe } from '@angular/common';

export interface Account {
  login: string;
  name: string;
  creationDate: DatePipe
  champions?: Champion[];
}
