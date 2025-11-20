import { type FC } from 'react';
import NavLinkHome from '@/components/layout/Header/NavLinkHome';
import SearchBar from '@/components/layout/Header/SearchBar';
import UserMenu from '@/components/layout/Header/UserMenu';

const Header: FC = () => (
  <header className="p-3 flex gap-4 flex-wrap items-center w-full justify-between sticky top-0 z-10 flex-col md:flex-row bg-cyan-950/50 backdrop-blur-3xl border-b-accent/40 border-b rounded-b-2xl shadow-accent/20 shadow-lg">
    <NavLinkHome />
    <div className="flex flex-col md:flex-row gap-4 items-center justify-center flex-wrap">
      <SearchBar />
      <UserMenu />
    </div>
  </header>
);

export default Header;
