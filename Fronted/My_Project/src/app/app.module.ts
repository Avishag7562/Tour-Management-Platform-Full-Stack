import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { RouterModule, Routes } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './comps/home/home.component';
import { RegisterComponent } from './comps/register/register.component';
import { TripDetailsComponent } from './comps/trip-details/trip-details.component';
import { HttpClientModule } from '@angular/common/http';
import { TripsComponent } from './comps/trips/trips.component';
import { UsersComponent } from './comps/users/users.component';
import { PersonalInfoComponent } from './comps/personal-info/personal-info.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RegisterComponent,
    TripDetailsComponent,
    TripsComponent,
    UsersComponent,
    PersonalInfoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([]),
    ReactiveFormsModule,
    HttpClientModule
  ],

  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
