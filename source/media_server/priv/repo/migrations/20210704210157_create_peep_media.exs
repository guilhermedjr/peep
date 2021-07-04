defmodule MediaServer.Repo.Migrations.CreatePeepMedia do
  use Ecto.Migration

  def change do
    create table(:peep_media, primary_key: false) do
      add :id, :binary_id, primary_key: true
      add :peep, :uuid
      add :index, :integer
      add :media_type, :integer
      add :media, :binary

      timestamps()
    end

  end
end
