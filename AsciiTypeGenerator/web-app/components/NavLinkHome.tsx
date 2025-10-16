'use client';

import { type FC } from 'react';
import { usePathname } from 'next/navigation';
import Link from 'next/link';
import { PAGE_URLS } from '@/shared/constants/pageUrls';

const NavLinkHome: FC = () => {
  const pathname = usePathname();
  const isActive = pathname === PAGE_URLS.HOME;

  return (
    <Link
      className={`group font-heading transition-colors ${
        isActive ? 'text-accent' : 'text-white hover:text-accent'
      }`}
      href={PAGE_URLS.HOME}
    >
      Ascii
      <span
        className={`transition-colors ${
          isActive ? 'text-white' : 'text-accent group-hover:text-white'
        }`}
      >
        Type
      </span>
      Generator
    </Link>
  );
};

export default NavLinkHome;
