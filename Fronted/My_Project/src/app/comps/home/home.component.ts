import { Component, DoCheck, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  loggedUser :string = 'customer'

  constructor(public route:Router, public userSer:UserService){}

  ngOnInit(): void {
    this.updateLoggedInUser();
  }

  ngDoCheck(): void {
    this.updateLoggedInUser();
  }

  updateLoggedInUser() {
    if (this.userSer.currentUser && typeof this.userSer.currentUser.FirstName === 'string') {
      this.loggedUser = this.userSer.currentUser.FirstName
    }
    else if(this.userSer.manager == true)
      this.loggedUser = 'Manager'
  }

  
  
}
