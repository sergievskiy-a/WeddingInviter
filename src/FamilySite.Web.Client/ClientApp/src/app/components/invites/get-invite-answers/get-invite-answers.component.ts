import { Component, OnInit, Inject, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Invite } from '../../../models/invite';
import { Guest } from '../../../models/guest';
import { InviteAnswer } from '../../../models/inviteAnswer';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-get-invite-answers',
  templateUrl: './get-invite-answers.component.html',
  styleUrls: ['./get-invite-answers.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class GetInviteAnswersComponent implements OnInit {

  public invites: Invite[];

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {
  }

  ngOnInit() {
    this.http.get<Invite[]>(environment.baseApiUrl + 'api/invites/answers', { withCredentials: true }).subscribe(result => {
          this.invites = result;
      }, error => {
        console.log(error);
      });
  }
}
