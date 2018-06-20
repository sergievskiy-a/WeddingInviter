import { Component, OnInit, Inject, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Invite } from '../../../models/invite';
import { Guest } from '../../../models/guest';
import { InviteAnswer } from '../../../models/inviteAnswer';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-get-invite',
  templateUrl: './get-invite.component.html',
  styleUrls: ['./get-invite.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class GetInviteComponent implements OnInit {

  public alias: string;
  public invite: Invite;
  public greeting: string;
  public loading: boolean;
  public step: number;

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.alias = params['alias'];
    });

    this.http.get<Invite>(environment.baseApiUrl + 'api/invites/' + this.alias).subscribe(result => {
        if (result) {
          this.invite = result;
        } else {
          this.router.navigateByUrl('/');
        }

        const hasAnswer = this.invite.inviteAnswer && (this.invite.inviteAnswer.going === true || this.invite.inviteAnswer.going === false);
        if (hasAnswer) {
          this.step = 3;
        } else {
          this.invite.inviteAnswer = new InviteAnswer();
          this.step = 1;
        }
        this.setGreeting(this.invite.guests);
      }, error => {
        this.router.navigateByUrl('/');
        console.log(error);
      });
  }

  setGreeting(guests: Guest[]) {
    if (this.invite.customGreeting) {
      this.greeting = this.invite.customGreeting;
    } else {

      if (guests.length === 1) {
        this.greeting = this.greeting + guests[0].firstName + '!';
      } else if (guests.length === 2) {
        this.greeting = 'Дорогі ';
        this.greeting = this.greeting + guests[0].firstName + ' and ' + guests[1].firstName + '!';
      } else {
        this.greeting = 'Дорогі ';
        for (let _i = 0; _i < guests.length - 1; _i++) {
          this.greeting = this.greeting + guests[_i].firstName + ', ';
        }
        this.greeting = this.greeting + guests[guests.length - 1].firstName + '!';
      }
    }
  }

  setGoing(isGoing: boolean) {
    this.step = 2;
    this.invite.inviteAnswer.going = isGoing;

    if (!isGoing) {
      this.step = 4;
      this.loading = true;
      this.http.post(environment.baseApiUrl + 'api/invites/' + this.alias + '/answer', this.invite.inviteAnswer).subscribe(response => {
        const result = response;
        this.loading = false;
      }, error => console.error(error));
    }
  }

  save() {
    this.loading = true;
    this.http.put(environment.baseApiUrl + 'api/invites/' + this.alias + '/answer', this.invite.inviteAnswer)
    .subscribe(response => {
      const result = response;
      this.step = 3;
      this.loading = false;
    }, error => {
      this.step = -1;
      console.error(error);
    });
  }
}
