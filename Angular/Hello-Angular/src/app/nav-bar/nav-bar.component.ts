import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor(private readonly router:Router) { }

  ngOnInit(): void {
  }

  goToProfile(){
    //You must include router dependency to use the router class to navigate through your website using methods
    this.router.navigate(["/profile"]);
  }
}
