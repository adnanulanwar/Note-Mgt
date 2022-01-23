import { Component, OnInit } from '@angular/core';
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

  constructor(private cs: CommonService) { }

  ngOnInit(): void {
  }

  public Register() {
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
    user.Name = this.name;
    user.Password = this.password;
    user.Email = this.email;
    user.DateOfBirth = new Date(this.dateOfBirth);

    this.cs.Register(user).subscribe((data) => {
      let user = data as User;
      if (user.UserID > 0) {
        alert("Success");
      }
      else {
        alert("Failed");
      }
    })
  }

}
