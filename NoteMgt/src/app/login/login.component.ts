import { Component, OnInit } from '@angular/core';
import { User } from '../Models/User';
import { CommonService } from '../services/common.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public name: string = "";
  public password: string = "";

  constructor(private cs: CommonService) { }


  ngOnInit(): void {
  }
  public Login() {
    if (this.name.trim() === "") {
      alert("Please Provide User Name");
      return;
    }
    if (this.password.trim() === "") {
      alert("Please Provide Password");
      return;
    }
    let user = new User();
    user.Name = this.name;
    user.Password = this.password;
    this.cs.Login(user).subscribe((data) => {
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
