import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Invite } from '../../../models/invite';
import { Guest } from '../../../models/guest';

@Component({
  selector: 'app-create-invite',
  templateUrl: './create-invite.component.html',
  styleUrls: ['./create-invite.component.css']
})
export class CreateInviteComponent {
  public invite: Invite;

  constructor(private http: HttpClient) {
    this.invite = new Invite();
  }

  addGuest() {
    this.invite.guests.push(new Guest());
  }

  save() {
    this.http.post('http://localhost:5000/api/invites', this.invite, { withCredentials: true }).subscribe(response => {
      const result = response;
    }, error => console.error(error));
  }
}
