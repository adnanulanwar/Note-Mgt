import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public data: any;

  constructor(private router: Router) {
    this.data = [
      { firstName: 'John', lastName: 'Doe', age: '35' },
      { firstName: 'Michael', lastName: 'Smith', age: '39' },
      { firstName: 'Michael', lastName: 'Jordan', age: '45' },
      { firstName: 'Tanya', lastName: 'Blake', age: '47' }
    ];
  }

  ngOnInit(): void {
  }

  @HostListener('click', ['$event'])
  private itemClicked(event: any): void {

    let itemID = event.target.id;
    if (itemID == 'btnRegular') {
      this.router.navigate(['/notes/1']);
    }
    if (itemID == 'btnReminder') {
      this.router.navigate(['/notes/2']);
    }
    if (itemID == 'btnTask') {
      this.router.navigate(['/notes/3']);
    }
    if (itemID == 'btnBookmark') {
      this.router.navigate(['/notes/4']);
    }
  }

}
