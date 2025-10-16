import { type FC } from 'react';
import NavLinkHome from './NavLinkHome';

const Header: FC = () => (
  <header className="mx-auto max-w-5xl p-10 flex items-center w-full justify-between">
    <NavLinkHome />
  </header>
);

export default Header;
