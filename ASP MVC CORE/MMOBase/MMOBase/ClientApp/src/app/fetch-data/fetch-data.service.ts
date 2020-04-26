import { Injectable } from '@angular/core';
import { HttpClient, } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Account } from '../models/Account';

@Injectable({
  providedIn: 'root'
})

export class FetchDataService<T extends Account> {

  private readonly accountsWithChampions = environment.accountsWithChampions;

  constructor(private http: HttpClient) {}

  public getAll() {
    return this.http.get<T>(this.accountsWithChampions).toPromise();
  }
}
