import axios from 'axios';
import { IRequestTransactionEntity } from '../../../../types/IRequestTransactionEntity';

export class UpdateTransaction {
  public update = async (
    url: string,
    entity: IRequestTransactionEntity,
  ): Promise<void> => {
    await axios.put(url, entity);
  };
}
