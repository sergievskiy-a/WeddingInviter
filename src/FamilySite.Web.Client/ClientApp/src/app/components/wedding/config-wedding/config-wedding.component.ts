import { Component, OnInit } from '@angular/core';
import { WeddingInfo } from '../../../models/weddingInfo';
import { Event } from '../../../models/event';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-config-wedding',
  templateUrl: './config-wedding.component.html',
  styleUrls: ['./config-wedding.component.css']
})
export class ConfigWeddingComponent implements OnInit {

  public wedding: WeddingInfo;
  public events: Event[];

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.http.get<WeddingInfo>('http://localhost:5000/api/wedding/info').subscribe(result => {
      this.wedding = result;
    }, error => console.error(error));

    this.http.get<Event[]>('http://localhost:5000/api/events/all').subscribe(result => {
      this.events = result;
    }, error => console.error(error));
  }

  save() {
    this.http.put('http://localhost:5000/api/wedding', this.wedding, { withCredentials: true }).subscribe(response => {
      const wedding = response;
    }, error => console.error(error));
  }
}
