import { Champion } from './Champion';
import { DatePipe } from '@angular/common';

export interface Account {
  Login: string;
  Name: string;
  creationDate?: Date
  champions?: Champion[];
}
