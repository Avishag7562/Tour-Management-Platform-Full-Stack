import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/classes/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{
  signupForm: FormGroup = new FormGroup({});

  loginForm: FormGroup = new FormGroup({});

  userList : Array<User> = new Array<User>()

  updateForm: FormGroup = new FormGroup({});
  
  newU:User = new User()

  showForm: boolean = true

  @Input() update: boolean =false

  n:number=0




  constructor(public userSer:UserService,public r:Router){}


  ngOnInit(): void {

    this.userSer.getAll().subscribe(
      succ=>{  
       this.userList = succ
      },
      err=>{
       alert(err.message)
      })

    this.signupForm = new FormGroup({

      firstName: new FormControl(null, [
        Validators.required,
        Validators.minLength(5),
        Validators.pattern('[A-Za-z]{2,10}')
      ]),

      lastName: new FormControl(null, [
        Validators.required,
        Validators.minLength(5),
        Validators.pattern('[A-Za-z]+')
      ]),

      email: new FormControl(null, [
        Validators.required,
        Validators.minLength(5),
        Validators.pattern('[A-Za-z]+@[a-zA-Z]+[.]+[a-zA-Z]{2,3}')
      ]),
      password: new FormControl(null, [
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(10),
        Validators.pattern('[A-Za-z1-9]+')
      ])
    });


    this.loginForm = new FormGroup({
      email: new FormControl(null, [
        Validators.required,
        Validators.minLength(5),
        Validators.pattern('[A-Za-z]+@[a-zA-Z]+[.]+[a-zA-Z]{2,3}')
      ]),
      password: new FormControl(null, [
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(10),
        Validators.pattern('[A-Za-z1-9]+')
      ])
    });
  }

  signUp() {
    const email = this.newU.Email ?? '';
  
    this.userSer.getByMailAndPassword(this.newU.Email!, this.newU.EntryPassword!).subscribe(
      existingUser => {
        if (existingUser) {
          alert("User with this email and password already exists. Please use different credentials.");
        } else {
          this.userSer.add(this.newU).subscribe(
            succ => {
              this.newU.CodeUser = succ;
              this.userSer.currentUser = this.newU;
  
              // Navigate to trips page upon successful registration
              this.r.navigate(['/trips']);
            },
            err => {
              alert(err.message);
            }
          );
        }
      },
      error => {
        alert(error.message);
      }
    );
  }
  
  
    logIn() {
      
      if (this.newU.Email === localStorage.getItem("Email") && this.newU.EntryPassword === localStorage.getItem("Password")) {
        this.userSer.manager = true;
        this.r.navigate(['/trips']);
      } else {
        debugger
        this.userSer.add(this.newU).subscribe(
          success => {
            this.n = success
            this.userSer.currentUser = this.newU

            this.r.navigate(['/trips']);
          },
          error => {
            alert(error.message)
            //alert("Incorrect email or password. Please try again.");
          }
        );
            this.newU = new User();
      }
    }
    
    toggleLoginForm(): void {
      this.showForm = !this.showForm
    }


  
    


}

