import PlateLayout from '../layout/PlateLayout';
import PlateFormView from '../views/PlateFormView';
import PlateLayoutForm from '../layout/PlateLayoutForm';

export default function PlateCreatePage() {
  return (
    <PlateLayout>
      <PlateLayoutForm title={'Create Plate'}>
        <PlateFormView />
      </PlateLayoutForm>
    </PlateLayout>
  );
}
