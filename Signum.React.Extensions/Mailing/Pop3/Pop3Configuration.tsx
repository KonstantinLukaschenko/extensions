import * as React from 'react'
import { ValueLine, EntityRepeater } from '@framework/Lines'
import { ValueSearchControlLine } from '@framework/Search'
import { TypeContext } from '@framework/TypeContext'
import { Pop3ConfigurationEntity, EmailMessageEntity } from '../Signum.Entities.Mailing'

export default function Pop3Configuration(p : { ctx: TypeContext<Pop3ConfigurationEntity> }){
  const sc = p.ctx;

  return (
    <div>
      <ValueLine ctx={sc.subCtx(s => s.active)} />
      <ValueLine ctx={sc.subCtx(s => s.port)} />
      <ValueLine ctx={sc.subCtx(s => s.host)} />
      <ValueLine ctx={sc.subCtx(s => s.username)} />
      <ValueLine ctx={sc.subCtx(s => s.password)} valueHtmlAttributes={{ type: "password" }} />
      <ValueLine ctx={sc.subCtx(s => s.enableSSL)} />
      <ValueLine ctx={sc.subCtx(s => s.readTimeout)} />
      <ValueLine ctx={sc.subCtx(s => s.deleteMessagesAfter)} />
      <EntityRepeater ctx={sc.subCtx(s => s.clientCertificationFiles)} />
    </div>
  );
}

