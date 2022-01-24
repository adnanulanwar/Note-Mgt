import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Note } from '../Models/Note';
import { CommonService } from '../services/common.service';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css']
})
export class NotesComponent implements OnInit {

  //private noteType : number = 0;
  public data: Note[] = [];
  constructor(private _activeRouterLink: ActivatedRoute, private cs: CommonService) { }

  ngOnInit(): void {

    this._activeRouterLink.paramMap.subscribe(param => {

      let noteType = param.get('type');
      let note = new Note()
      var id = sessionStorage.getItem("USERID");
      note.UserID = id ? parseInt(id) : 0;
      note.NoteType = noteType ? parseInt(noteType) : 0;
      this.cs.GetNotes(note).subscribe((data) => {
        debugger
        this.data = data as Note[];

      })

    })
  }



}
