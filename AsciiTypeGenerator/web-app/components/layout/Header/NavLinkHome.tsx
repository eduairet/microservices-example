'use client';

import Link from 'next/link';
import { usePathname } from 'next/navigation';
import { type FC } from 'react';
import { pageUrls } from '@/shared/constants';

const NavLinkHome: FC = () => {
  const pathname = usePathname();
  const isActive = pathname === pageUrls.HOME;

  return (
    <Link
      className={`group font-heading text-2xl transition-colors ${
        isActive ? 'text-accent' : 'text-white hover:text-accent'
      }`}
      href={pageUrls.HOME}
    >
      {'Ascii Type Generator'.split(' ').map((word, index) => (
        <span
          key={index}
          className={
            index === 1 ? (isActive ? 'text-white' : 'text-accent group-hover:text-white') : ''
          }
        >
          {[...word].map((char, charIndex) => (
            <span key={charIndex} className={charIndex > 0 ? 'hidden md:inline' : ''}>
              {char}
            </span>
          ))}
        </span>
      ))}
      <span
        className={`inline md:hidden ${isActive ? ' text-white' : ' text-accent group-hover:text-white'}`}
      >
        _
      </span>
    </Link>
  );
};

export default NavLinkHome;
