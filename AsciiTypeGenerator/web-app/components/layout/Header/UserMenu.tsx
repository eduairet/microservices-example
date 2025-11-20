'use client';

import IconAccount from '@/components/icons/IconAccount';
import useOutsideClick from '@/hooks/useOutsideClick';
import { login } from '@/shared/services';
import { useEffect, useRef, useState } from 'react';

const UserMenu = () => {
  const [isOpen, setIsOpen] = useState(false);
  const ref = useRef<HTMLDivElement>(null);

  // TODO: Move to Zustand
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [token, setToken] = useState<string | null>(null);
  const handleLogin = async (email: string, password: string) => {
    const token = await login(email, password);
    localStorage.setItem('authToken', token);
    setToken(token);
    setIsAuthenticated(true);
  };
  const handleLogout = () => {
    localStorage.removeItem('authToken');
    setToken(null);
    setIsAuthenticated(false);
  };

  useOutsideClick(ref, () => {
    if (isOpen) setIsOpen(false);
  });

  useEffect(() => {
    const token = localStorage.getItem('authToken');
    setToken(token);
    setIsAuthenticated(!!token);
  }, []);

  return (
    <div ref={ref} className="relative">
      <button
        className={`relative p-2 bg-accent transition-[color,box-shadow] duration-300 hover:text-white rounded-full cursor-pointer ${isOpen ? 'ring-2 ring-white text-white' : 'text-cyan-950'}`}
        aria-label="User Menu"
        onClick={() => setIsOpen(!isOpen)}
      >
        <IconAccount aria-hidden="true" height={24} width={24} />
      </button>
      {isOpen && (
        <div className="absolute right-0 top-full mt-8 w-48 bg-foreground rounded-md shadow-lg shadow-cyan-950 z-10">
          {isAuthenticated && token ? (
            <div>
              <p className="p-4 text-cyan-950">Token: {token}</p>
              <button
                className="w-full text-left px-4 py-2 bg-red-600 text-white rounded-b-md hover:bg-red-700"
                onClick={handleLogout}
              >
                Log Out
              </button>
            </div>
          ) : (
            <form
              className="flex flex-col p-4 gap-2"
              onSubmit={async e => {
                e.preventDefault();
                const formData = new FormData(e.currentTarget);
                const email = formData.get('email') as string;
                const password = formData.get('password') as string;
                await handleLogin(email, password);
              }}
            >
              <input
                type="email"
                name="email"
                placeholder="Email"
                className="border border-gray-300 rounded px-2 py-1 text-gray-900"
                required
              />
              <input
                type="password"
                name="password"
                placeholder="Password"
                className="border border-gray-300 rounded px-2 py-1 text-gray-900"
                required
              />
              <button type="submit" className="bg-cyan-950 text-white rounded px-2 py-1">
                Log In
              </button>
            </form>
          )}
        </div>
      )}
    </div>
  );
};

export default UserMenu;
