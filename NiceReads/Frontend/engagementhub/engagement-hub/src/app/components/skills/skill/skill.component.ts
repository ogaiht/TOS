import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-skill',
  templateUrl: './skill.component.html',
  styleUrls: ['./skill.component.scss']
})
export class SkillComponent implements OnInit {

  public skillForm: FormGroup;

  constructor() {
    this.skillForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      description: new FormControl('')
    });
  }

  ngOnInit(): void {

  }

  public onSubmit(): void {
    if (this.skillForm.touched && this.skillForm.valid) {

    }
  }
}
