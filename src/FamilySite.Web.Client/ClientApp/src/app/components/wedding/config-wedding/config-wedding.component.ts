import { Component, OnInit } from '@angular/core';
import { WeddingInfo } from '../../../models/weddingInfo';
import { Event } from '../../../models/event';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment.dev';

@Component({
  selector: 'app-config-wedding',
  templateUrl: './config-wedding.component.html',
  styleUrls: ['./config-wedding.component.css']
})
export class ConfigWeddingComponent implements OnInit {

  public wedding: WeddingInfo;

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.http.get<WeddingInfo>(environment.baseApiUrl + 'api/wedding/info').subscribe(result => {
      this.wedding = result;
    }, error => console.error(error));
  }

  addEvent() {
    this.wedding.events.push(new Event());
  }

  eventDeleted(eventId: number) {
    this.wedding.events = this.wedding.events.filter(item => item.id !== eventId);
  }

  save() {
    this.http.put(environment.baseApiUrl + 'api/wedding', this.wedding, { withCredentials: true }).subscribe(response => {
      const wedding = response;
    }, error => console.error(error));
  }
}
