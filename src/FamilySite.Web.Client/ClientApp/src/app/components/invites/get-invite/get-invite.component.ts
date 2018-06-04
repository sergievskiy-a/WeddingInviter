import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Invite } from '../../../models/invite';
import { Guest } from '../../../models/guest';
import { InviteAnswer } from '../../../models/inviteAnswer';

@Component({
  selector: 'app-get-invite',
  templateUrl: './get-invite.component.html',
  styleUrls: ['./get-invite.component.css']
})
export class GetInviteComponent implements OnInit {

  public alias: string;
  public invite: Invite;
  public greeting: string;
  public showTwoButtons: boolean;
  public choosedGoing: boolean;
  public hasAnswer: boolean;

  constructor(private http: HttpClient, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.alias = params['alias'];
    });

    this.http.get<Invite>('http://localhost:5000/api/invites/' + this.alias).subscribe(result => {
      this.invite = result;
      this.hasAnswer = this.invite.inviteAnswer && (this.invite.inviteAnswer.going === true || this.invite.inviteAnswer.going === false);
      if (!this.hasAnswer) {
        this.invite.inviteAnswer = new InviteAnswer();
        this.showTwoButtons = true;
      }
      this.setGreeting(this.invite.guests);
    }, error => console.error(error));
  }

  setGreeting(guests: Guest[]) {
    if (this.invite.customGreeting) {
      this.greeting = this.invite.customGreeting;
    }
    else {

      this.greeting = 'Dear ';

      if (guests.length === 1) {
        this.greeting = this.greeting + guests[0].firstName + '!';
      } else if (guests.length === 2) {
        this.greeting = this.greeting + guests[0].firstName + ' and ' + guests[1].firstName + '!';
      } else {
        for (let _i = 0; _i < guests.length - 1; _i++) {
          this.greeting = this.greeting + guests[_i].firstName + ', ';
        }
        this.greeting = this.greeting + guests[guests.length - 1].firstName + '!';
      }
    }
  }

  setGoing(isGoing: boolean) {
    this.showTwoButtons = false;
    this.invite.inviteAnswer.going = isGoing;
    this.choosedGoing = isGoing;

    if (!isGoing) {
      this.hasAnswer = true;
      this.http.post('http://localhost:5000/api/invites/' + this.alias + '/answer', this.invite.inviteAnswer).subscribe(response => {
        const result = response;
      }, error => console.error(error));
    }
  }

  save() {
    this.hasAnswer = true;
    this.http.post('http://localhost:5000/api/invites/' + this.alias + '/answer', this.invite.inviteAnswer).subscribe(response => {
      const result = response;
    }, error => console.error(error));
  }
}
