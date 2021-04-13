import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EventoService } from 'src/app/evento/service/evento.service';
import { FormGroup, NgForm ,FormBuilder, Validators} from '@angular/forms';

@Component({
  selector: 'app-evento-adicionar',
  templateUrl: './adicionar.component.html',
  styleUrls: ['./adicionar.component.css']
})
export class AdicionarComponent implements OnInit {
  registerForm: FormGroup;
  private isLoadingResults = false;

  constructor(private router: Router, private api: EventoService, private formBuilder: FormBuilder) { }

  ngOnInit() {
   
    this.registerForm = this.formBuilder.group({
      'sensor' : [null, Validators.required],
      'pais' : [null, Validators.required],
      'regiao' : [null, Validators.required],
      'valor' : [null, Validators.required]
      
    });
  }

  get f() { return this.registerForm.controls; }
  
  public addEvento(form: NgForm) {
    this.isLoadingResults = true;
    this.api.addEvento(this.registerForm.value)
      .subscribe(res => {
          this.isLoadingResults = false;
          this.router.navigate(['/evento-listar']);
        }, (err) => {
          console.log(err);
          this.isLoadingResults = false;
        });
  }
}
