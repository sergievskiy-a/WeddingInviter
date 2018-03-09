import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigWeddingComponent } from './config-wedding.component';

describe('ConfigWeddingComponent', () => {
  let component: ConfigWeddingComponent;
  let fixture: ComponentFixture<ConfigWeddingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfigWeddingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfigWeddingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
