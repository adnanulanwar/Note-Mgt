import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../Models/User';
import { CommonService } from '../services/common.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  public name = "";
  public email = "";
  public password = "";
  public password2 = "";
  public dateOfBirth: string = "";
  public returnUser: User = new User();

  constructor(private cs: CommonService, private router: Router,) { }

  ngOnInit(): void {
  }

  public Register() {
    debugger
    if (this.name.trim() === "") {
      alert("Please Provide User Name");
      return;
    }
    if (this.email.trim() === "") {
      alert("Please Provide User Name");
      return;
    }
    if (this.password.trim() === "" || this.password2 === "") {
      alert("Please Provide Password");
      return;
    }
    if (this.password.trim() !== this.password2.trim()) {
      alert("Password didn't match");
    }
    if (this.dateOfBirth.trim() === "") {
      alert("Please Provide Date of Birth");
      return;
    }

    let user = new User();
    user.name = this.name;
    user.password = this.password;
    user.email = this.email;
    user.dateOfBirth = new Date(this.dateOfBirth);

    this.cs.Register(user).subscribe((data) => {
      debugger
      let user = data as User;
      //alert(user.ErrorMessage);
      if (this.returnUser.userID > 0) {
      this.router.navigate(['/login']);
      }
    })
  }

}
