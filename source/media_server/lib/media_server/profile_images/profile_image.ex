defmodule MediaServer.ProfileImages.ProfileImage do
  use Ecto.Schema
  import Ecto.Changeset

  @primary_key {:id, :binary_id, autogenerate: true}
  @foreign_key_type :binary_id
  schema "profile_image" do
    field :image, :binary
    field :user, Ecto.UUID

    timestamps()
  end

  @doc false
  def changeset(profile_image, attrs) do
    profile_image
    |> cast(attrs, [:user, :image])
    |> validate_required([:user, :image])
  end
end
