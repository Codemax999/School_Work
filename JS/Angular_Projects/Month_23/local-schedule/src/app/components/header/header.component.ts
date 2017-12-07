import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  // --- Component Variables ---
  form: FormGroup;
  city: string = '';
  

  // --- LifeCycle ---
  ngOnInit() {

    // initialize form 
    this.form = new FormGroup({
      city: new FormControl(this.city, Validators.maxLength(50))
    });
  }


  // --- Show / Hide Header Search Bar ---
  // if on results page
  searchBar(): boolean {
    if (window.location.pathname === '/results') return true;
    else return false;
  }
}
