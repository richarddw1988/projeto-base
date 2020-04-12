import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { of, throwError } from 'rxjs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterTestingModule } from '@angular/router/testing';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';

import { LoginComponent } from './login.component';
import { NotificationService } from '../../shared/notification/notification.service';
import { SharedModule } from '../../shared/shared.module';
import { UsuarioModel } from 'src/app/core/domain/entity/usuario-model';
import { AppMaterialModule } from 'src/app/app-material.module';
import { IUsuarioController } from 'src/app/core/interfaces/controllers/iusuario-controller';

describe('Component: Login', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  let usuarioController: jasmine.SpyObj<IUsuarioController>;

  beforeEach(async(() => {
    const controllerSpy = jasmine.createSpyObj('IUsuarioController', ['login', 'logout']);

    TestBed.configureTestingModule({
      declarations: [ LoginComponent ],
      providers: [
        FormBuilder,
        NotificationService,
        { provide: IUsuarioController, useValue: controllerSpy }
      ],
      imports: [
        RouterTestingModule,
        ReactiveFormsModule,
        AppMaterialModule,
        BrowserAnimationsModule,
        SharedModule
      ]
    })
    .compileComponents();

    usuarioController = TestBed.get(IUsuarioController);
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('deve criar', () => {
    expect(component).toBeTruthy();
  });

  describe('login', () => {
    it('deve retornar um usuario', () => {
      const param = {
        username: 'test',
        password: '123'
      };

      usuarioController.login.and.returnValue(of(new UsuarioModel()));

      component.login();

      expect(usuarioController.login.calls.count()).toBe(1);

      usuarioController.login(param).subscribe(usuario => {
        if (usuario) {
          expect(usuario).toBeTruthy();
        }
      });
    });

    it('deve retornar um usuario null', () => {
      const param = {
        username: 'test',
        password: '123'
      };

      usuarioController.login.and.returnValue(of(null));

      component.login();

      expect(usuarioController.login.calls.count()).toBe(1);

      usuarioController.login(param).subscribe(usuario => {
        if (!usuario) {
          expect(usuario).toBeNull();
        }
      });
    });

    it('deve retornar um erro', () => {
      const param = {
        username: '',
        password: ''
      };

      usuarioController.login.and.returnValue(throwError(''));

      component.login();

      expect(usuarioController.login.calls.count()).toBe(1);

      usuarioController.login(param);
    });
  });
});
