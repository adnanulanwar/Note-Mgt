import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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

  constructor(private cs: CommonService, private router: Router) { }


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
    user.name = this.name;
    user.password = this.password;
    this.cs.Login(user).subscribe((data) => {
      debugger
      let user = data as User;
  
      if (user.userID > 0) {
        alert("Success");
        sessionStorage.removeItem("USERID");
        sessionStorage.setItem("USERID", user.userID.toString());
        this.router.navigate(['/dashboard']);
      }
      else {
        alert("Failed");
      }
    })
  }

}
