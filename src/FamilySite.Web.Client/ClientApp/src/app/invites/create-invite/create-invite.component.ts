import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Invite } from '../../models/invite';
import { Guest } from '../../models/guest';

@Component({
  selector: 'app-create-invite',
  templateUrl: './create-invite.component.html',
  styleUrls: ['./create-invite.component.css']
})
export class CreateInviteComponent {

  public invite: Invite;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Invite>(baseUrl + 'api/invite/alias').subscribe(result => {
      this.invite = result;
    }, error => console.error(error));
  }
}
