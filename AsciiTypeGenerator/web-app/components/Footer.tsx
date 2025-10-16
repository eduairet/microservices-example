import IconGitHub from '@/components/icons/IconGitHub';

export default function Footer() {
  return (
    <footer className="text-sm mx-auto max-w-5xl p-10 flex flex-col sm:flex-row gap-2 sm:gap-4 items-center w-full justify-between row-start-3">
      <span>{`Eduardo Aire Torres ${new Date().getFullYear()}`}</span>
      <a
        className="flex gap-1 items-center transition-colors hover:text-accent underline"
        href="https://github.com/eduairet/microservices-example/tree/main/AsciiTypeGenerator/web-app"
        target="_blank"
        rel="noopener noreferrer"
      >
        <IconGitHub aria-hidden width={24} height={24} />
        GitHub
      </a>
    </footer>
  );
}
