import { SVGProps, type FC } from 'react';
import IconWrapper from '@/components/icons/IconWrapper';

interface IProps extends SVGProps<SVGSVGElement> {
  width?: number;
  height?: number;
}

const IconAccount: FC<IProps> = ({ width = 64, height = 64, ...props }) => {
  return (
    <IconWrapper width={width} height={height} viewBox="0 0 640 640" {...props}>
      <path
        fill="currentColor"
        d="M320 312C386.3 312 440 258.3 440 192C440 125.7 386.3 72 320 72C253.7 72 200 125.7 200 192C200 258.3 253.7 312 320 312zM290.3 368C191.8 368 112 447.8 112 546.3C112 562.7 125.3 576 141.7 576L498.3 576C514.7 576 528 562.7 528 546.3C528 447.8 448.2 368 349.7 368L290.3 368z"
      />
    </IconWrapper>
  );
};

export default IconAccount;
