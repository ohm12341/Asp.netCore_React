import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { VitalsService } from '@app/_services';
import { Vitals } from '@app/_models';
import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Observable } from 'rxjs';

@Component({ templateUrl: 'allvitals.component.html' })
export class AllVitalsComponent implements OnInit {
  vitalForm: FormGroup;
  vitasllist: Observable<any[]>;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private vitalsService: VitalsService
  ) {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  ngOnInit() {
    this.vitalForm = this.formBuilder.group({
      businessUnitId: ['', Validators.required],
      deviceId: ['', Validators.required],
      heartRate: ['', Validators.required],
      temperature: ['', Validators.required],
    });
    this.vitasllist = this.vitalsService.Get();
    // get return url from route parameters or default to '/'
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.vitalForm.controls;
  }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.vitalForm.invalid) {
      return;
    }

    this.loading = true;
    let vaital = new Vitals();
    vaital.businessUnitId = this.f.businessUnitId.value;
    vaital.deviceId = this.f.businessUnitId.value;
    vaital.heartRate = this.f.heartRate.value;
    vaital.temperature = this.f.temperature.value;
  }

  onClick() {
    this.router.navigate(['login']);
  }
}
