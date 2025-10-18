import type { Metadata } from 'next';
import '@/app/globals.css';
import Footer from '@/components/layout/Footer';
import Header from '@/components/layout/Header';
import MainContainer from '@/components/layout/MainContainer';
import { asap, azeretMono } from '@/shared/fonts';

export const metadata: Metadata = {
  title: 'AsciiTypeGenerator',
  description: 'Generate ASCII art from text using different fonts created by the community.',
  icons: {
    icon: '/favicon.svg',
  },
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body
        className={`grid grid-rows-[auto_1fr_auto] grid-cols-1 min-h-screen ${asap.variable} ${azeretMono.variable} antialiased`}
      >
        <Header />
        <MainContainer>{children}</MainContainer>
        <Footer />
      </body>
    </html>
  );
}
