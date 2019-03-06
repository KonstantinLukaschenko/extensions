import * as React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { AuthMessage, UserEntity, UserState } from '../Signum.Entities.Authorization'
import { Binding } from '@framework/Reflection'
import { ValueLine, EntityLine, EntityCombo, FormGroup, TypeContext } from '@framework/Lines'

export default function User(p: { ctx: TypeContext<UserEntity> }) {

  const ctx = p.ctx.subCtx({ labelColumns: { sm: 3 } });
  const entity = p.ctx.value;

  return (
    <div>
      <ValueLine ctx={ctx.subCtx(e => e.state, { readOnly: true })} />
      <ValueLine ctx={ctx.subCtx(e => e.userName)} />
      <DoublePassword ctx={new TypeContext<string>(ctx, undefined, undefined as any, Binding.create(ctx.value, v => v.newPassword))} isNew={entity.isNew} /> :
      <EntityLine ctx={ctx.subCtx(e => e.role)} />
      <ValueLine ctx={ctx.subCtx(e => e.email)} />
      <EntityCombo ctx={ctx.subCtx(e => e.cultureInfo)} />
      <ValueLine ctx={ctx.subCtx(e => e.passwordNeverExpires)} />
      <ValueLine ctx={ctx.subCtx(e => e.passwordSetDate)} />
    </div>
  );
}

function DoublePassword(p: { ctx: TypeContext<string>, isNew: boolean }) {

  const [withPassword, setWithPassword] = React.useState(p.isNew);

  if (!withPassword) {
    return <FormGroup labelText={AuthMessage.NewPassword.niceToString()} ctx={p.ctx}>
      <a className="btn btn-light btn-sm" onClick={() => setWithPassword(true)}>
        <FontAwesomeIcon icon="key" /> {AuthMessage.ChangePassword.niceToString()}
      </a>
    </FormGroup>
  }


  function handlePasswordBlur(e: React.SyntheticEvent<any>) {
    const ctx = p.ctx;

    if (newPass.current!.value && newPass2.current!.value && newPass.current!.value != newPass2.current!.value) {
      ctx.error = AuthMessage.PasswordsAreDifferent.niceToString()
    }
    else {
      ctx.error = undefined;
      ctx.value = newPass.current!.value;
    }

    ctx.frame!.revalidate();
  }

  var newPass = React.useRef<HTMLInputElement>(null);
  var newPass2 = React.useRef<HTMLInputElement>(null);

  return (
    <div>
      <FormGroup ctx={p.ctx} labelText={AuthMessage.ChangePasswordAspx_NewPassword.niceToString()}>
        <input type="password" ref={newPass} className={p.ctx.formControlClass} onBlur={handlePasswordBlur} />
      </FormGroup>
      <FormGroup ctx={p.ctx} labelText={AuthMessage.ChangePasswordAspx_ConfirmNewPassword.niceToString()}>
        <input type="password" ref={newPass2} className={p.ctx.formControlClass} onBlur={handlePasswordBlur} />
      </FormGroup>
    </div>
  );
}

