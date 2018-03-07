import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Invite } from '../../models/invite';
import { Guest } from '../../models/guest';

@Component({
  selector: 'app-get-invite',
  templateUrl: './get-invite.component.html',
  styleUrls: ['./get-invite.component.css']
})
export class GetInviteComponent {

  public invite: Invite;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Invite>('http://localhost:5000/api/invite/alias').subscribe(result => {
      this.invite = result;
    }, error => console.error(error));
  }
}
