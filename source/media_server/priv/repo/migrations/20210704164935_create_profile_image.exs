defmodule MediaServer.Repo.Migrations.CreateProfileImage do
  use Ecto.Migration

  def change do
    create table(:profile_image) do
      add :user, :string
      add :imagePath, :string

      timestamps()
    end

  end
end
