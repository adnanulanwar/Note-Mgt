import { Component, HostListener, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public data: any;

  constructor() {
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
    if (itemID == 'crossmodal2') {
      // this.closeClicked.emit({ close: true });
      // this.ms.setClickedOption('Close');
    }
    if (itemID == 'messageModalCloseBtn') {
      // this.closeClicked.emit({ close: true });
      // this.ms.setClickedOption('Close');
    }
  }

}
