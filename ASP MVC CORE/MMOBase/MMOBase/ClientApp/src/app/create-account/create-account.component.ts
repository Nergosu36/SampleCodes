import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { environment } from '../../environments/environment';
import { Account } from '../models/Account';

@Component({
  selector: 'app-create-account',
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.css']
})
export class CreateAccountComponent implements OnInit {

  accountWithChampions: Account = {
    Login: '',
    Name: ''
  }

  private readonly newAccount = environment.newAccount;

  uploadForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient) { }

  ngOnInit() {
    this.uploadForm = this.formBuilder.group({
      inputLogin: [''],
      inputName: ['']
    });
  }

  onSubmit() {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    this.accountWithChampions.Login = this.uploadForm.get('inputLogin').value;
    this.accountWithChampions.Name = this.uploadForm.get('inputName').value;

    console.log(this.accountWithChampions);

    this.httpClient.post(this.newAccount, this.accountWithChampions, httpOptions).subscribe(
      (res) => console.log(res),
      (err) => console.log(err)
    );
  }

}
