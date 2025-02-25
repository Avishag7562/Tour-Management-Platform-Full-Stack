import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/classes/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit{
  constructor(public userSer:UserService){}

  userList:Array<User>=new Array<User>()

  ngOnInit(): void {
    this.userSer.getAll().subscribe(
      succ => {
        this.userList = succ
      },
      err=>{
        alert(err.message)
       }
    )
  }

}
