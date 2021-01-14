import { Component } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Store } from '@ngxs/store';
import { AppComplexity } from 'src/app/models/app-complexity';
import { DataTypes } from 'src/app/models/data-types';
import { CreateArchitecture } from 'src/app/store/app.actions';

@Component({
  selector: 'app-architecture-form',
  templateUrl: './architecture-form.component.html',
  styleUrls: ['./architecture-form.component.scss']
})
export class ArchitectureFormComponent {

  public complexities = [
    { id: AppComplexity.low, label: 'Low' },
    { id: AppComplexity.average, label: 'Average' },
    { id: AppComplexity.big, label: 'Big' }
  ];

  public dataTypes = [
    { id: DataTypes.normalData, label: 'Normal data' },
    { id: DataTypes.sensitiveData, label: 'Sensitive data' }
  ]

  architectureForm: FormGroup = this.formBuilder.group({
    dependencyNumber: ['', [Validators.required, Validators.min(1)]],
    acceptableDowntime: ['', [Validators.required, Validators.min(1)]],
    syncronicUserNumber: ['', [Validators.required, Validators.min(1)]],
    packetNumberPerSession: ['', [Validators.required, Validators.min(1)]],
    applicationComplexity: ['', Validators.required],
    dataTypeUsed: ['', Validators.required],
  });

  constructor(private store: Store, private formBuilder: FormBuilder) { }

  submitArchitecture(): void {
    if (this.architectureForm.valid) {
      this.store.dispatch(new CreateArchitecture(this.architectureForm.value));
    }
  }

}
