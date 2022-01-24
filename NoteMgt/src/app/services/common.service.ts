import { HttpClient } from '@angular/common/http';
import { not } from '@angular/compiler/src/output/output_ast';
import { Injectable } from '@angular/core';
import { Note } from '../Models/Note';
import { User } from '../Models/User';

@Injectable({
  providedIn: 'root'
})
export class CommonService {

  private readonly baseUrl = "https://localhost:44383/api/"

  constructor(private http: HttpClient) { }

  public Login(user: User) {
    return this.http.post(this.baseUrl + "User/Login", user)
  }

  public Register(user: User) {
    return this.http.post(this.baseUrl + "User/Register", user)
  }

  public Save(note: Note) {
    return this.http.post(this.baseUrl + "Note/SaveNote", note)
  }

  public GetNotes(note: Note) {
    return this.http.post(this.baseUrl + "Note/GetNotesByType", note)
  }
}
