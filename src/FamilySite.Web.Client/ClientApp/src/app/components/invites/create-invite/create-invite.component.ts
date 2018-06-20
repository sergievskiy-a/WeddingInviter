import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Invite } from '../../../models/invite';
import { Event } from '../../../models/event';
import { Guest } from '../../../models/guest';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-create-invite',
  templateUrl: './create-invite.component.html',
  styleUrls: ['./create-invite.component.css']
})
export class CreateInviteComponent implements OnInit {
  public invite: Invite;
  public events: Event[];
  public selectedEvent: Event;

  constructor(private http: HttpClient) {
    this.invite = new Invite();
  }

  ngOnInit() {
    this.http.get<Event[]>(environment.baseApiUrl + 'api/events/all').subscribe(result => {
      this.events = result;
    }, error => console.error(error));
  }

  addGuest() {
    this.invite.guests.push(new Guest());
  }

  save() {
    this.invite.eventId = this.selectedEvent.id;
    this.http.post<Invite>(environment.baseApiUrl + 'api/invites', this.invite, { withCredentials: true }).subscribe(response => {
      this.invite = response;
    }, error => console.error(error));
  }
}
